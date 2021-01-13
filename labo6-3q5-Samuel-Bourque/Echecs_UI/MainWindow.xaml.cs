using CasEchecs_Affaires;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Echecs_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Position Origine { get; set; }
        public Position Destination { get; set; }
        private ObservableCollection<Piece> _pieces;
        public MainWindow()
        {
            Origine = new Position(1, 1);
            Destination = new Position(1, 2);
            InitializeComponent();
            this.DataContext = this;
            Echiquier.ItemsSource = _pieces = new ObservableCollection<Piece>
            {
                new Pion(CouleurPiece.Noir, new Position(0,6)),
                new Pion(CouleurPiece.Noir, new Position(1,6)),
                new Pion(CouleurPiece.Noir, new Position(2,6)),
                new Pion(CouleurPiece.Noir, new Position(3,6)),
                new Pion(CouleurPiece.Noir, new Position(4,6)),
                new Pion(CouleurPiece.Noir, new Position(5,6)),
                new Pion(CouleurPiece.Noir, new Position(6,6)),
                new Pion(CouleurPiece.Noir, new Position(7,6)),
                new Tour(CouleurPiece.Noir, new Position(0,7)),
                new Cavalier(CouleurPiece.Noir, new Position(1,7)),
                new Fou(CouleurPiece.Noir, new Position(2,7)),
                new Roi(CouleurPiece.Noir, new Position(3,7)),
                new Reine(CouleurPiece.Noir, new Position(4,7)),
                new Fou(CouleurPiece.Noir, new Position(5,7)),
                new Cavalier(CouleurPiece.Noir, new Position(6,7)),
                new Tour(CouleurPiece.Noir, new Position(7,7)),

                new Pion(CouleurPiece.Blanc, new Position(0,1)),
                new Pion(CouleurPiece.Blanc, new Position(1,1)),
                new Pion(CouleurPiece.Blanc, new Position(2,1)),
                new Pion(CouleurPiece.Blanc, new Position(3,1)),
                new Pion(CouleurPiece.Blanc, new Position(4,1)),
                new Pion(CouleurPiece.Blanc, new Position(5,1)),
                new Pion(CouleurPiece.Blanc, new Position(6,1)),
                new Pion(CouleurPiece.Blanc, new Position(7,1)),
                new Tour(CouleurPiece.Blanc, new Position(0,0)),
                new Cavalier(CouleurPiece.Blanc, new Position(1,0)),
                new Fou(CouleurPiece.Blanc, new Position(2,0)),
                new Roi(CouleurPiece.Blanc, new Position(3,0)),
                new Reine(CouleurPiece.Blanc, new Position(4,0)),
                new Fou(CouleurPiece.Blanc, new Position(5,0)),
                new Cavalier(CouleurPiece.Blanc, new Position(6,0)),
                new Tour(CouleurPiece.Blanc, new Position(7,0))
            };
        }

        private void BtnChargerPieces_Click(object sender, RoutedEventArgs e)
        {
            _pieces.Clear();
            char typePiece = ' ';
            CouleurPiece couleur = CouleurPiece.Blanc;
            int rangee = 0;
            int colonne = 0;

            BinaryReader br = new BinaryReader(new FileStream("echiquier.dat", FileMode.Open));
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                typePiece = br.ReadChar();

                bool etatBlanche = br.ReadBoolean();
                if (etatBlanche == false)
                    couleur = CouleurPiece.Noir;

                rangee = br.ReadByte() -1; 

                char noColonne = br.ReadChar();

                switch (noColonne)
                {
                    case 'A':
                        colonne = 0;
                        break;
                    case 'B':
                        colonne = 1;
                        break;
                    case 'C':
                        colonne = 2;
                        break;
                    case 'D':
                        colonne = 3;
                        break;
                    case 'E':
                        colonne = 4;
                        break;
                    case 'F':
                        colonne = 5;
                        break;
                    case 'G':
                        colonne = 6;
                        break;
                    case 'H':
                        colonne = 7;
                        break;
                }

                switch (typePiece)
                {
                    case 'R':
                        _pieces.Add(new Roi(couleur, new Position(colonne, rangee)));
                        break;
                    case 'D':
                        _pieces.Add(new Reine(couleur, new Position(colonne, rangee)));
                        break;
                    case 'T':
                        _pieces.Add(new Tour(couleur, new Position(colonne, rangee)));
                        break;
                    case 'F':
                        _pieces.Add(new Fou(couleur, new Position(colonne, rangee)));
                        break;
                    case 'C':
                        _pieces.Add(new Cavalier(couleur, new Position(colonne, rangee)));
                        break;
                    default:
                        _pieces.Add(new Pion(couleur, new Position(colonne, rangee)));
                        break;
                }
            }
            br.Close();
        }
    }

    public enum PieceType
    {
        Pion,
        Tour,
        Cavalier,
        Fou,
        Reine,
        Roi
    }

    public enum Player
    {
        Blanc,
        Noir
    }

    public class ChessPiece : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Point _Pos;
        public Point Pos
        {
            get { return this._Pos; }
            set { this._Pos = value; OnPropertyChanged("Pos"); }
        }

        private PieceType _Type;
        public PieceType Type
        {
            get { return this._Type; }
            set { this._Type = value; OnPropertyChanged("Type"); }
        }

        private Player _Player;
        public Player Player
        {
            get { return this._Player; }
            set { this._Player = value; OnPropertyChanged("Player"); }
        }
    }
}
