//-----------------------------------------------------------------------
// <copyright file="GameStateVM.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using Chess.Command;
    using Chess.Model;
    using Chess.Model.ChessPieces;

    /// <summary>
    /// Represents the GameStateVM class.
    /// </summary>
    public class GameStateVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the command arguments.
        /// </summary>
        private CommandLineArgumentsHandler commandLineArgumentsHandler;

        /// <summary>
        /// Represents the GameBoard.
        /// </summary>
        private GameBoard gameBoard;

        /// <summary>
        /// Represents the GameBoardCreator.
        /// </summary>
        private GameBoardCreator gameBoardCreator;

        /// <summary>
        /// Represents the MoveCalculator.
        /// </summary>
        private MoveCalculator moveCalculator;

        /// <summary>
        /// Represents the GameBoard row.
        /// </summary>
        private int row;

        /// <summary>
        /// Represents the GameBoard column.
        /// </summary>
        private int column;

        /// <summary>
        /// Represents the ObservableCollection of GameHistory.
        /// </summary>
        private ObservableCollection<GameBoard> gameHistory;

        /// <summary>
        /// Represents the ObservableCollection of possible moves.
        /// </summary>
        private ObservableCollection<Coordinates> possibleMoves;

        /// <summary>
        /// Represents the ObservableCollection of beaten black pieces.
        /// </summary>
        private ObservableCollection<ChessPiece> beatenBlackPieces;

        /// <summary>
        /// Represents the ObservableCollection of beaten white pieces.
        /// </summary>
        private ObservableCollection<ChessPiece> beatenWhitePieces;

        /// <summary>
        /// Represents if the white king is beaten.
        /// </summary>
        private bool isWhiteKingBeaten;

        /// <summary>
        /// Represents if the black king is beaten.
        /// </summary>
        private bool isBlackKingBeaten;

        /// <summary>
        /// Represents the GameWinner Calculator.
        /// </summary>
        private GameWinnerCalculator gameWinnerCalculator;

        /// <summary>
        /// Represents if is white king in check.
        /// </summary>
        private bool isWhiteKingInCheck;

        /// <summary>
        /// Represents if is black king in check.
        /// </summary>
        private bool isBlackKingInCheck;

        /// <summary>
        /// Represents if it is a winner.
        /// </summary>
        private bool isAWinner;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateVM"/> class.
        /// </summary>
        public GameStateVM()
        {
            this.commandLineArgumentsHandler = new CommandLineArgumentsHandler();

            this.row = this.commandLineArgumentsHandler.GameBoardSize[0];
            this.column = this.commandLineArgumentsHandler.GameBoardSize[1];

            this.gameBoardCreator = new GameBoardCreator();

            this.beatenBlackPieces = new ObservableCollection<ChessPiece>();
            this.beatenWhitePieces = new ObservableCollection<ChessPiece>();

            this.gameHistory = new ObservableCollection<GameBoard>();

            this.possibleMoves = new ObservableCollection<Coordinates>();

            this.moveCalculator = new MoveCalculator();

            this.gameWinnerCalculator = new GameWinnerCalculator();

            this.isBlackKingInCheck = false;
            this.isWhiteKingInCheck = false;
            this.isAWinner = false;

            this.StartGame();
        }

        /// <summary>
        /// Represents the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the value of the game board.
        /// </summary>
        /// <value>The value of game board.</value>
        public GameBoard GameBoard
        {
            get
            {
                return this.gameBoard;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.GameBoard), "The specified value must not be null!");
                }

                this.gameBoard = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the cells.
        /// </summary>
        /// <value>The value of the cells.</value>
        public Cell[,] Cells
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of the selected coordinates.
        /// </summary>
        /// <value>The value of the selected cell.</value>
        public Coordinates SelectCell
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the a ObservableCollection of the game board history.
        /// </summary>
        /// <value>The ObservableCollection of the game board history.</value>
        public ObservableCollection<GameBoard> GameHistory
        {
            get
            {
                return this.gameHistory;
            }

            set
            {
                this.gameHistory = value;
            }
        }

        /// <summary>
        /// Gets or sets the a ObservableCollection of the possible moves.
        /// </summary>
        /// <value>The ObservableCollection of the possible moves.</value>
        public ObservableCollection<Coordinates> PossibleMoves
        {
            get
            {
                return this.possibleMoves;
            }

            set
            {
                this.possibleMoves = value;
            }
        }

        /// <summary>
        /// Gets or sets the a ObservableCollection of the beaten black pieces.
        /// </summary>
        /// <value>The ObservableCollection of the beaten black pieces.</value>
        public ObservableCollection<ChessPiece> BeatenBlackPieces
        {
            get
            {
                return this.beatenBlackPieces;
            }

            set
            {
                this.beatenBlackPieces = value;
            }
        }

        /// <summary>
        /// Gets or sets the a ObservableCollection of the beaten white pieces.
        /// </summary>
        /// <value>The ObservableCollection of the beaten white pieces.</value>
        public ObservableCollection<ChessPiece> BeatenWhitePieces
        {
            get
            {
                return this.beatenWhitePieces;
            }

            set
            {
                this.beatenWhitePieces = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the white king is beaten.
        /// </summary>
        /// <value>The value of White Player Won.</value>
        public bool IsWhiteKingBeaten
        {
            get
            {
                return this.isWhiteKingBeaten;
            }

            set
            {
                this.isWhiteKingBeaten = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the black king is beaten.
        /// </summary>
        /// <value>The value of Black Player Won.</value>
        public bool IsBlackKingBeaten
        {
            get
            {
                return this.isBlackKingBeaten;
            }

            set
            {
                this.isBlackKingBeaten = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the white player won.
        /// </summary>
        /// <value>The value of white player won.</value>
        public bool IsWhitePlayerWon
        {
            get
            {
                return (this.gameHistory.IndexOf(this.gameBoard) % 2 == 0) && this.IsWhiteKingInCheck;
            }

            set
            {
                this.IsWhitePlayerWon = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the white king is in check.
        /// </summary>
        /// <value>The value of black player won.</value>
        public bool IsWhiteKingInCheck
        {
            get
            {
                return this.isWhiteKingInCheck;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the black player won.
        /// </summary>
        /// <value>The value of black player won.</value>
        public bool IsBlackPlayerWon
        {
            get
            {
                return (this.gameHistory.IndexOf(this.gameBoard) % 2 != 0) && this.IsBlackKingInCheck;
            }

            set
            {
                this.IsBlackPlayerWon = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the black king is in check.
        /// </summary>
        /// <value>The value of black player won.</value>
        public bool IsBlackKingInCheck
        {
            get
            {
                return this.isBlackKingInCheck;
            }
        }

        /// <summary>
        /// Gets the value of new game.
        /// </summary>
        /// <value>The value of new game.</value>
        public ICommand NewGameCommand
        {
            get
            {
                return new Command(obj => this.StartGame());
            }
        }

        /// <summary>
        /// Gets the value of exit game.
        /// </summary>
        /// <value>The value of exit game.</value>
        public ICommand ExitGameCommand
        {
            get
            {
                return new Command(obj => Environment.Exit(0));
            }
        }

        /// <summary>
        /// Gets the value of load turn.
        /// </summary>
        /// <value>The value of load turn.</value>
        public ICommand LoadTurnCommand
        {
            get
            {
                return new Command(obj =>
                {
                    int gameIndex = (int)obj;

                    if (gameIndex >= 0)
                    {
                        try
                        {
                            this.gameBoard = this.gameHistory[gameIndex];
                            this.BeatenWhitePieces = new ObservableCollection<ChessPiece>(this.gameBoard.BeatenWhitePieces);
                            this.BeatenBlackPieces = new ObservableCollection<ChessPiece>(this.gameBoard.BeatenBlackPieces);
                            this.UpdateGameState();
                        }
                        catch
                        {
                            this.UpdateGameState();
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Gets the value of select cell.
        /// </summary>
        /// <value>The value of select cell.</value>
        public ICommand SelectCellCommand
        {
            get
            {
                return new Command(obj =>
                {
                    if (!this.IsBlackPlayerWon && !IsWhitePlayerWon)
                    {
                        if (this.SelectCell != null)
                        {
                            this.MovePiece((string)obj);
                            this.FireOnPropertyChanged(nameof(this.PossibleMoves));

                            this.FireOnPropertyChanged(nameof(this.IsBlackPlayerWon));
                            this.FireOnPropertyChanged(nameof(this.IsWhitePlayerWon));
                            return;
                        }

                        this.SelectPiece((string)obj);
                        this.FireOnPropertyChanged(nameof(this.PossibleMoves));
                    }
                    else if (this.IsBlackPlayerWon || IsWhitePlayerWon)
                    {
                        this.isAWinner = true;
                        this.FireOnPropertyChanged(nameof(this.IsAGameWinner));
                    }
                });
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether it is a winner.
        /// </summary>
        /// <value>The value of black player won.</value>
        public bool IsAGameWinner
        {
            get
            {
                return this.isAWinner;
            }

            set
            {
                this.isAWinner = value;
            }
        }

        /// <summary>
        /// Gets the value of game state changed.
        /// </summary>
        /// <value>The value of game state changed.</value>
        public ICommand GameStateChangedCommand
        {
            get
            {
                return new Command(obj =>
                {
                    NotifyVMAboutGameState();
                });
            }
        }

        /// <summary>
        /// Gets the chess move status.
        /// </summary>
        /// <param name="oldCoordinates">Specified the old coordinates of the selected piece.</param>
        /// <param name="newCoordinates">Specified the new coordinates of the selected piece.</param>
        /// <param name="rowCount">Specified the row count of the game board.</param>
        /// <returns>Returns a string representing the chess move status.</returns>
        public string GetMoveStatus(Coordinates oldCoordinates, Coordinates newCoordinates, int rowCount)
        {
            string oldPiecePosition = this.ConvertIntToChar(oldCoordinates.YCoordinate) + (rowCount - oldCoordinates.XCoordinate).ToString();
            string newPiecePosition = this.ConvertIntToChar(newCoordinates.YCoordinate) + (rowCount - newCoordinates.XCoordinate).ToString();

            return $"{oldPiecePosition} -> {newPiecePosition}";
        }

        /// <summary>
        /// Fires the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Specified the property name.</param>
        protected virtual void FireOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Converts a integer number to a char.
        /// </summary>
        /// <param name="number">Specified the number.</param>
        /// <returns>The letter of the number.</returns>
        private char ConvertIntToChar(int number)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (number < 0 || number >= letters.Length)
            {
                return '\0';
            }

            return letters[number];
        }

        /// <summary>
        /// Start the ChessGame.
        /// </summary>
        private void StartGame()
        {
            GameBoard gameBoard = this.gameBoardCreator.Create(this.column, this.row, "startofgame");

            this.gameHistory.Clear();
            this.gameHistory.Add(gameBoard);
            this.possibleMoves.Clear();

            this.gameBoard = gameBoard;

            this.BeatenBlackPieces.Clear();
            this.BeatenWhitePieces.Clear();

            this.isAWinner = false;
            this.isBlackKingInCheck = false;
            this.isWhiteKingInCheck = false;

            this.UpdateGameState();
        }

        /// <summary>
        /// Notify the VM about the Game State.
        /// </summary>
        private void NotifyVMAboutGameState()
        {
            this.gameBoard = this.gameHistory[this.gameHistory.Count - 1];

            this.row = this.gameBoard.Row;
            this.column = this.gameBoard.Column;

            this.BeatenBlackPieces = new ObservableCollection<ChessPiece>(this.gameBoard.BeatenBlackPieces);
            this.BeatenWhitePieces = new ObservableCollection<ChessPiece>(this.gameBoard.BeatenWhitePieces);

            this.UpdateGameState();
        }

        /// <summary>
        /// Get coordinates from chess piece.
        /// </summary>
        /// <param name="piece">Specified the chess piece.</param>
        /// <returns>The coordinates from piece.</returns>
        private int[] GetCoordinatesFromPiece(string piece)
        {
            int[] coordinates = new int[2];
            string[] pieceInfo = piece.Split(' ');

            coordinates[0] = int.Parse(pieceInfo[0]);
            coordinates[1] = int.Parse(pieceInfo[1]);

            return coordinates;
        }

        /// <summary>
        /// Select a chess piece.
        /// </summary>
        /// <param name="piece">Specified the chess piece.</param>
        private void SelectPiece(string piece)
        {
            int[] selectedCell = this.GetCoordinatesFromPiece(piece);

            Coordinates selectedPieceCoordinates = new Coordinates(selectedCell[0], selectedCell[1]);

            if (this.gameBoard.Cells[selectedPieceCoordinates.XCoordinate, selectedPieceCoordinates.YCoordinate].IsCellOccupied)
            {
                ChessPiece chessPiece = this.gameBoard.Cells[selectedPieceCoordinates.XCoordinate, selectedPieceCoordinates.YCoordinate].ChessPiece;

                if (this.gameHistory.IndexOf(this.gameBoard) % 2 == 0)
                {
                    if (chessPiece.Player == Player.SecondPlayer)
                    {
                        this.GetPossibleMoves(selectedPieceCoordinates);
                    }
                }
                else
                {
                    if (chessPiece.Player == Player.FirstPlayer)
                    {
                        this.GetPossibleMoves(selectedPieceCoordinates);
                    }
                }
            }
        }

        /// <summary>
        /// Get the possible moves.
        /// </summary>
        /// <param name="selectedPieceCoordinates">Specified the selected piece coordinates.</param>
        private void GetPossibleMoves(Coordinates selectedPieceCoordinates)
        {
            List<Coordinates> possibleMoves;

            if (this.gameBoard.Cells[selectedPieceCoordinates.XCoordinate, selectedPieceCoordinates.YCoordinate].IsCellOccupied)
            {
                possibleMoves = this.gameBoard.Cells[selectedPieceCoordinates.XCoordinate, selectedPieceCoordinates.YCoordinate].ChessPiece.Move(this.moveCalculator, this.gameBoard, selectedPieceCoordinates);
            }
            else
            {
                return;
            }

            ObservableCollection<Coordinates> coordinates = new ObservableCollection<Coordinates>(possibleMoves);
            this.possibleMoves = coordinates;
            this.SelectCell = selectedPieceCoordinates;
        }

        /// <summary>
        /// Move the chess piece.
        /// </summary>
        /// <param name="piece">Specified the chess piece.</param>
        private void MovePiece(string piece)
        {
            int[] oldCoordinates = this.GetCoordinatesFromPiece(piece);
            Coordinates moveCoordinates = new Coordinates(oldCoordinates[0], oldCoordinates[1]);

            foreach (Coordinates possibleCoordinates in this.possibleMoves)
            {
                if (moveCoordinates.XCoordinate == possibleCoordinates.XCoordinate && moveCoordinates.YCoordinate == possibleCoordinates.YCoordinate)
                {
                    GameBoard newGameState = this.CreateNewGameState(this.SelectCell, moveCoordinates);

                    if (this.gameBoard != this.gameHistory[this.gameHistory.Count - 1])
                    {
                        while (this.gameBoard != this.gameHistory[this.gameHistory.Count - 1])
                        {
                            this.gameHistory.Remove(this.gameHistory[this.gameHistory.Count - 1]);
                        }
                    }

                    foreach (ChessPiece chessPiece in this.BeatenBlackPieces)
                    {
                        newGameState.BeatenBlackPieces.Add(chessPiece);
                    }

                    foreach (ChessPiece chesspiece in this.BeatenWhitePieces)
                    {
                        newGameState.BeatenWhitePieces.Add(chesspiece);
                    }

                    this.gameHistory.Add(newGameState);
                    this.gameBoard = newGameState;

                    this.isBlackKingInCheck = this.gameWinnerCalculator.CalculateIsKingInCheck(Player.FirstPlayer, this.gameBoard);
                    this.isWhiteKingInCheck = this.gameWinnerCalculator.CalculateIsKingInCheck(Player.SecondPlayer, this.gameBoard);

                    this.FireOnPropertyChanged(nameof(this.IsWhiteKingInCheck));
                    this.FireOnPropertyChanged(nameof(this.IsBlackKingInCheck));

                    this.possibleMoves.Clear();

                    this.FireOnPropertyChanged(nameof(this.BeatenBlackPieces));
                    this.FireOnPropertyChanged(nameof(this.BeatenWhitePieces));

                    this.FireOnPropertyChanged(nameof(this.GameBoard));
                    this.FireOnPropertyChanged(nameof(this.PossibleMoves));
                    this.SelectCell = null;
                    break;
                }
            }

            this.SelectPiece(piece);
        }

        /// <summary>
        /// Create a new game state.
        /// </summary>
        /// <param name="oldCoordinates">Specified the old coordinates from chess piece.</param>
        /// <param name="newCoordinates">Specified the new coordinates from chess piece.</param>
        /// <returns>The new GameBoard.</returns>
        private GameBoard CreateNewGameState(Coordinates oldCoordinates, Coordinates newCoordinates)
        {
            Cell[,] newBoard = new Cell[this.gameBoard.Row, this.gameBoard.Column];

            for (int i = 0; i < this.gameBoard.Row; i++)
            {
                for (int j = 0; j < this.gameBoard.Column; j++)
                {
                    newBoard[i, j] = new Cell(this.gameBoard.Cells[i, j].IsCellOccupied, this.gameBoard.Cells[i, j].ChessPiece);
                }
            }

            ChessPiece movingChessPiece = newBoard[oldCoordinates.XCoordinate, oldCoordinates.YCoordinate].ChessPiece;

            ChessPiece beatenChessPiece;
            bool chessPieceDied = this.CheckIfChessPieceBeaten(newBoard, newCoordinates);

            if (chessPieceDied)
            {
                beatenChessPiece = newBoard[newCoordinates.XCoordinate, newCoordinates.YCoordinate].ChessPiece;

                this.BeatChessPiece(beatenChessPiece);
            }

            newBoard[newCoordinates.XCoordinate, newCoordinates.YCoordinate].ChessPiece = movingChessPiece;
            newBoard[newCoordinates.XCoordinate, newCoordinates.YCoordinate].IsCellOccupied = true;
            newBoard[oldCoordinates.XCoordinate, oldCoordinates.YCoordinate].IsCellOccupied = false;

            string moveName = this.GetMoveStatus(oldCoordinates, newCoordinates, this.gameBoard.Row);
            GameBoard gameBoard = new GameBoard(this.gameBoard.Column, this.gameBoard.Row, moveName, newBoard);

            return gameBoard;
        }

        /// <summary>
        /// Check if the chess piece is beaten.
        /// </summary>
        /// <param name="gameBoard">Specified the Game Board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating the piece state.</returns>
        private bool CheckIfChessPieceBeaten(Cell[,] gameBoard, Coordinates coordinates)
        {
            return gameBoard[coordinates.XCoordinate, coordinates.YCoordinate].IsCellOccupied;
        }

        /// <summary>
        /// Beat a chess piece.
        /// </summary>
        /// <param name="beatenChessPiece">Specified the chess piece.</param>
        private void BeatChessPiece(ChessPiece beatenChessPiece)
        {
            switch (beatenChessPiece.Player)
            {
                case Player.FirstPlayer:
                    this.BeatenBlackPieces.Add(beatenChessPiece);
                    this.FireOnPropertyChanged(nameof(this.BeatenBlackPieces));
                    break;
                case Player.SecondPlayer:
                    this.BeatenWhitePieces.Add(beatenChessPiece);
                    this.FireOnPropertyChanged(nameof(this.BeatenWhitePieces));
                    break;
            }
        }

        /// <summary>
        /// Update the GameStateVM.
        /// </summary>
        private void UpdateGameState()
        {
            this.FireOnPropertyChanged(nameof(this.BeatenBlackPieces));
            this.FireOnPropertyChanged(nameof(this.BeatenWhitePieces));
            this.FireOnPropertyChanged(nameof(this.GameHistory));
            this.FireOnPropertyChanged(nameof(this.GameBoard));
            this.FireOnPropertyChanged(nameof(this.IsWhitePlayerWon));
            this.FireOnPropertyChanged(nameof(this.IsBlackPlayerWon));
            this.FireOnPropertyChanged(nameof(this.IsWhiteKingInCheck));
            this.FireOnPropertyChanged(nameof(this.IsAGameWinner));
        }
    }
}