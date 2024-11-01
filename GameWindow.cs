using WINFSWEEPER.models;

namespace WINFSWEEPER;

public partial class GameWindow : Form
{
    public GameWindow(int rows, int columns, double bombPercentage)
    {
        InitializeComponent();
        GameSetup(rows, columns, bombPercentage);
    }
    private GameMaster? _objGame;

    private void GameSetup(int irows, int icolumns, double bombPercentage)
    {
        int rows = irows, columns = icolumns, bombAmount = (int) Math.Round( (double) (irows * icolumns) * bombPercentage);
        int buttonSize = 30;
        const int buttonSpacing = 2;

        if (rows <= 20 && columns <= 20)
        {
            if (rows <= 10 && columns <= 10)
            {
                buttonSize = 40;
            } else buttonSize = 35;
        }

        const int leftMargin = 5;
        const int rightMargin = 5;
        const int topMargin = 5;
        const int bottomMargin = 5;

        this.ClientSize = new(leftMargin + rightMargin + ((buttonSize + buttonSpacing) * (columns) - buttonSpacing),
            topMargin + bottomMargin + ((buttonSize + buttonSpacing) * (rows) - buttonSpacing)
            );
        this.CenterToScreen();
        Console.WriteLine($"SIZE: {this.Size.Width}, {this.Size.Height}");
        
        
        _objGame = new ( new MineField[columns, rows]);

        int id = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                id++;
                Button button = new Button();
                button.Size = new(buttonSize, buttonSize);
                button.Location = new Point(leftMargin + (buttonSize + buttonSpacing) * (j),
                    topMargin + (buttonSize + buttonSpacing) * (i));
                
                Console.WriteLine($"Button {j},{i} generated at ({button.Location.X},{button.Location.Y})");
                button.TabIndex = id;
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.Font = 
                    new System.Drawing.Font(
                        "Helvetica CE", 
                        13F,
                        System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point, 
                        ((byte)0)
                    );
                
                button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                button.Cursor = System.Windows.Forms.Cursors.Hand;
                button.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;

                button.FlatStyle = FlatStyle.Flat;

                MineField nMineField = new(id, button, _objGame, new Coordinates(j, i));
                _objGame.GameInformation[j, i] = nMineField;
                this.Controls.Add(button);
            }
        }
        
        _objGame.AssignBombs(bombAmount);
        foreach (MineField mField in _objGame.GameInformation)
        {
            if (mField.HasBomb) continue;
            else
            {
                int bAmount = _objGame.AnalyzeBombs(mField.Coords);
                mField.BombAmount = bAmount;
            }
        }
    }
}