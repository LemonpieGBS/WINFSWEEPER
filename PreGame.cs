namespace WINFSWEEPER;

public partial class PreGame : Form
{
    public PreGame()
    {
        InitializeComponent();
        lb_Error.Text = "";
    }

    private void btn_Go_Click(object sender, EventArgs e)
    {
        int min_button_size = 30;
        if (nud_Height.Value * min_button_size > Screen.PrimaryScreen.Bounds.Height ||
            nud_Width.Value * min_button_size > Screen.PrimaryScreen.Bounds.Width)
        {
            lb_Error.Text = "These game dimensions are not supported by the current display!";
            return;
        }

        lb_Error.Text = "";
        var frm = new GameWindow((int) nud_Height.Value, (int) nud_Width.Value, (double) nud_Bombs.Value / 100.0);
        frm.Location = this.Location;
        frm.StartPosition = FormStartPosition.Manual;
        frm.FormClosing += delegate { this.Show(); };
        frm.Text = $"WinFSweeper | ({nud_Height.Value}, {nud_Width.Value}) - GAME";
        frm.Show();
        this.Hide();
    }
}