

namespace GameUno
{
    public partial class SelectColorForm : Form
    {
        public CardColor Color = CardColor.Green;

        public SelectColorForm()
        {
            InitializeComponent();
            btnRed.Tag = CardColor.Red;
            btnYellow.Tag = CardColor.Yellow;
            btnGreen.Tag = CardColor.Green;
            btnBlue.Tag = CardColor.Blue;
        }

        public void Build(CardColor color)
        {
            Color = color;
            switch (Color)
            {
                case CardColor.Red:
                    btnRed.Focus();
                    break;
                case CardColor.Yellow:
                    btnYellow.Focus();
                    break;
                case CardColor.Green:
                    btnGreen.Focus();
                    break;
                case CardColor.Blue:
                    btnBlue.Focus();
                    break;
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            Color = CardColor.Red;
            DialogResult = DialogResult.OK;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            Color = CardColor.Yellow;
            DialogResult = DialogResult.OK;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            Color = CardColor.Green;
            DialogResult = DialogResult.OK;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            Color = CardColor.Blue;
            DialogResult = DialogResult.OK;
        }
    }
}
