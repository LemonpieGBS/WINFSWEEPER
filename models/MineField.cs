using Microsoft.VisualBasic.Devices;
using WINFSWEEPER.extensions;

namespace WINFSWEEPER.models;

class Coordinates(int x, int y)
{
    public int X = x;
    public int Y = y;

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Coordinates) return false;
        else return ((Coordinates) obj).X == this.X && ((Coordinates) obj).Y == this.Y;
    }
}

class GameMaster(MineField[,] gameContainer)
{
    private readonly MineField[,] _gameInformation = gameContainer;
    public MineField[,] GameInformation { get => _gameInformation; }
    public MineField? InitialRecommendation = null;
    public bool GameOver = false;

    public static Dictionary<int, Color> ColorDictionary = new Dictionary<int, Color>()
    {
        {1, Color.Blue},
        {2, Color.Green},
        {3, Color.Red},
        {4, Color.Fuchsia},
        {5, Color.Coral},
        {6, Color.Teal},
        {7, Color.DimGray},
        {8, Color.Yellow}
    };

    public void AssignBombs(int bombAmount)
    {
        int totalBombArea = _gameInformation.GetLength(0) * _gameInformation.GetLength(1);
        if (bombAmount > totalBombArea)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        Coordinates[] lottery = new Coordinates[totalBombArea];
        
        int totalPass = 0;
        for (int i = 0; i < _gameInformation.GetLength(1); i++)
        {
            for (int j = 0; j < _gameInformation.GetLength(0); j++)
            {
                lottery[totalPass] = new Coordinates(j, i);
                totalPass++;
            }
        }
        
        var rng = new Random();
        rng.Shuffle(lottery);

        for (int i = 0; i < bombAmount; i++)
        {
            _gameInformation[lottery[i].X, lottery[i].Y].HasBomb = true;
        }

        List<MineField> _0SpaceFields = [];
        foreach (MineField mineField in _gameInformation)
        {
            if (mineField.HasBomb) continue;
            
            if (AnalyzeBombs(mineField.Coords) == 0)
            {
                _0SpaceFields.Add(mineField);
            }
        }

        if (_0SpaceFields.Count != 0)
        {
            /*List<Tuple<MineField, int>> mineAmountPair = [];

            int VirtualSweep(Coordinates mineCoords, List<MineField> polledSpaces)
            {
                int spaceCovered = 0;
                List<MineField> surrFields = GetSurroundingFields(mineCoords);
                foreach (MineField mField in surrFields)
                {
                    if (mField.BombAmount == 0 && !polledSpaces.Contains(mField))
                    {
                        List<MineField> joint = new(surrFields);
                        joint.AddRange(polledSpaces);
                        spaceCovered += VirtualSweep(mField.Coords, joint);
                    }
                    else spaceCovered++;
                }
                
                Console.WriteLine($"0 space with {spaceCovered} spaces covered detected");
                return spaceCovered;
            }

            foreach (MineField mField in _0SpaceFields)
            {
                mineAmountPair.Add(new (mField, VirtualSweep(mField.Coords, [])));
            }
            
            mineAmountPair.Sort((x, y) => y.Item2.CompareTo(x.Item2));*/
            MineField[] nnconv = _0SpaceFields.ToArray();
            rng.Shuffle(nnconv);
            InitialRecommendation = nnconv[0];

            InitialRecommendation.Button.ForeColor = Color.Lime;
            InitialRecommendation.Button.Text = "❤️";
        }
    }

    private List<MineField> GetSurroundingFields(Coordinates bombCoords)
    {
        MineField mineField = _gameInformation[bombCoords.X, bombCoords.Y];
        
        bool altRight = (mineField.Coords.X == _gameInformation.GetLength(0) - 1),
            altLeft = (mineField.Coords.X == 0),
            altDown = (mineField.Coords.Y == _gameInformation.GetLength(1) - 1),
            altUp = (mineField.Coords.Y == 0);

        List<MineField> returnList = [];
        
        if (!altRight)
        {
            returnList.Add(_gameInformation[mineField.Coords.X + 1, mineField.Coords.Y]);

            if (!altDown) { 
                returnList.Add(_gameInformation[mineField.Coords.X + 1, mineField.Coords.Y + 1]); }
            
            if (!altUp) { 
                returnList.Add(_gameInformation[mineField.Coords.X + 1, mineField.Coords.Y - 1]); }
        }

        if (!altLeft)
        {
            returnList.Add(_gameInformation[mineField.Coords.X - 1, mineField.Coords.Y]);

            if (!altDown) {
                returnList.Add(_gameInformation[mineField.Coords.X - 1, mineField.Coords.Y + 1]); }
            
            if (!altUp) { 
                returnList.Add(_gameInformation[mineField.Coords.X - 1, mineField.Coords.Y - 1]); }
        }

        if (!altDown) { 
                returnList.Add(_gameInformation[mineField.Coords.X, mineField.Coords.Y + 1]); }

        if (!altUp) { 
                returnList.Add(_gameInformation[mineField.Coords.X, mineField.Coords.Y - 1]); }

        return returnList;
    }

    public int AnalyzeBombs(Coordinates bombCoords)
    {
        MineField mineField = _gameInformation[bombCoords.X, bombCoords.Y];

        int bombAmount = 0;
        List<MineField> mFields = GetSurroundingFields(bombCoords);

        foreach (MineField mField in mFields)
        {
            if (mField.HasBomb) bombAmount++;
        }

        return bombAmount;
    }

    public void Sweep(Coordinates bombCoords)
    {
        MineField mineField = _gameInformation[bombCoords.X, bombCoords.Y];
        
        if (mineField.HasBomb)
        {
            GameOver = true;
            foreach (MineField mField in _gameInformation)
            {
                if (!mField.FieldRevealed && mField.HasBomb)
                {
                    mField.FieldRevealed = true;
                    mField.Button.Text = "💣";
                    mField.Button.BackColor = Color.Red;
                    mField.Button.ForeColor = Color.White;
                    mField.Button.FlatAppearance.BorderColor = Color.Red;
                    mField.Button.FlatAppearance.MouseOverBackColor = Color.Red;
                    mField.Button.FlatAppearance.MouseDownBackColor = Color.Red;
                    mField.Button.Cursor = Cursors.UpArrow;
                } else if (!mField.FieldRevealed)
                {
                    //mField.Button.Enabled = false;
                    mField.Button.FlatAppearance.BorderColor = Color.WhiteSmoke;
                    mField.Button.Cursor = Cursors.Default;
                }
            }
        }
        else
        {
            mineField.FieldRevealed = true;
            if (mineField.BombAmount == 0)
            {
                List<MineField> surroundingF = GetSurroundingFields(bombCoords);
                
                foreach (MineField mField in surroundingF)
                {
                    if(!mField.FieldRevealed) Sweep(mField.Coords);
                }
            }

            mineField.Button.Text =
                (mineField.BombAmount > 0) ? mineField.BombAmount.ToString() : string.Empty;
            //mineField.Button.Enabled = false;
            mineField.Button.FlatAppearance.BorderColor = Color.WhiteSmoke;
            mineField.Button.Cursor = Cursors.Default;

            Color assignedColor = Color.Black;
            ColorDictionary.TryGetValue(mineField.BombAmount, out assignedColor);

            mineField.Button.ForeColor = assignedColor;
        }
    }

    public void SwiftSweep(Coordinates bombCoords)
    {
        MineField mineField = _gameInformation[bombCoords.X, bombCoords.Y];
        List<MineField> surroundingF = GetSurroundingFields(bombCoords);

        int flagCount = 0;
        foreach (MineField mField in surroundingF)
        {
            if(mField.FieldFlagged && !mField.FieldRevealed) flagCount++;
        }

        if (flagCount == mineField.BombAmount)
        {
            foreach (MineField mField in surroundingF)
            {
                if(!mField.FieldFlagged && !mField.FieldRevealed) Sweep(mField.Coords);
            }
        }
    }

    public void Flag(Coordinates bombCoords)
    {
        MineField mineField = _gameInformation[bombCoords.X, bombCoords.Y];

        if (InitialRecommendation is not null)
        {
            if (bombCoords.Equals(InitialRecommendation.Coords)) return;
        }
        
        if (mineField.FieldRevealed) return;

        if (!mineField.FieldFlagged)
        {
            mineField.FieldFlagged = true;
            mineField.Button.Text = "🚩";
            mineField.Button.ForeColor = Color.Red;
            mineField.Button.Cursor = Cursors.No;
        }
        else
        {
            mineField.FieldFlagged = false;
            mineField.Button.Text = "";
            mineField.Button.ResetForeColor();
            mineField.Button.Cursor = Cursors.Hand;
        }
    }
}

class MineField
{
    private int _id;
    public int BombAmount = 0;
    public bool FieldFlagged = false, HasBomb = false, FieldRevealed = false;
    private readonly System.Windows.Forms.Button _iBoundButton;
    private readonly GameMaster _objGame;
    private readonly Coordinates _coords;

    private void LeftClickEv(object? a, EventArgs e)
    {
        if (_objGame.GameOver) return;
        
        Console.WriteLine($"Left click event registered for {_coords}");
        if (!FieldFlagged)
        {
            if(!FieldRevealed) _objGame.Sweep(_coords);
            else _objGame.SwiftSweep(_coords);
        }
    }

    private void RightClickEv(object? a, EventArgs e)
    {
        if (_objGame.GameOver) return;
        
        Console.WriteLine($"Right click event registered for {_coords}");
        _objGame.Flag(_coords);
    }
    
    private void ClickEvent(object? a, EventArgs e)
    {
        MouseEventArgs me = (MouseEventArgs) e;

        if (me.Button == System.Windows.Forms.MouseButtons.Left)
        {
            LeftClickEv(a, e);
            
        } else if (me.Button == System.Windows.Forms.MouseButtons.Right)
        {
            RightClickEv(a, e);
        }
    }

    public MineField(int id, System.Windows.Forms.Button boundButton, GameMaster gameInformation, Coordinates coordinates)
    {
        this._id = id;
        this._iBoundButton = boundButton;
        boundButton.MouseUp += ClickEvent;
        
        this._objGame = gameInformation;
        this._coords = coordinates;
    }

    public System.Windows.Forms.Button Button
    {
        get { return _iBoundButton; }
    }

    public Coordinates Coords
    {
        get { return _coords; }
    }
}