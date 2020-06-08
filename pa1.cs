using System;
using static System.Console;

namespace BME121
{
    static class Program
    {
        static bool useBoxDrawingChars = true;
        static string[ ] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };
        static int boardSize = 7; // must be in the range 1..12.

        static double cellMarkProb = 0.2;
        static Random rGen = new Random( );

        static void Main( )
        {
            // Create arrays and initialize the game. 
       
            bool[ , ] userBoard = new bool[ boardSize, boardSize ]; 
            bool[ , ] hiddenBoard = new bool[ boardSize, boardSize ]; 
            int[ ] userColSums = new int[ boardSize ]; // arrays for column sums (used different method for row sums).
            int[ ] hiddenColSums = new int[ boardSize ]; 
            
            for(int row = 0; row < boardSize; row++)
            {
				for(int col = 0; col < boardSize; col++) 
				{
					if(rGen.NextDouble( ) < cellMarkProb)  
					{
						hiddenBoard[row, col] = true; // marks hiddenBoard (answer).  
					} else {
						hiddenBoard[row, col] = false; // don't mark hiddenBoard. 
					}
					
					if( hiddenBoard[row, col] == true) 
					{ 
						hiddenColSums[col] += row + 1; 
					}
					userBoard[row, col] = false; 
				}
			}

            // This is the main game-play loop.

            bool gameNotQuit = true;
            while( gameNotQuit )
            {
                Console.Clear( );
                WriteLine( );
                WriteLine( "    Play Kakurasu!" );
                WriteLine( );

                // Display the game board.

                if( useBoxDrawingChars )
                {
                    for( int row = 0; row < boardSize; row ++ ) 
                    {
                        if( row == 0 )
                        {
                            Write( "        " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( "  {0} ", letters[ col ] );
                            WriteLine( );

                            Write( "        " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( " {0,2} ", col + 1 );
                            WriteLine( );

                            Write( "        \u250c" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "\u2500\u2500\u2500\u252c" );
                            WriteLine( "\u2500\u2500\u2500\u2510" );
                        }

                        Write( "   {0} {1,2} \u2502", letters[ row ], row + 1 );
                        
                        // Set variables for row sums (both userBoard and hiddenBoard). 
                        
                        int sum1 = 0;
                        int hidden1 = 0;   
                        
                        for( int col = 0; col < boardSize; col ++ )
                        {
                            if( userBoard[row, col] == true  ) 
                            {
								Write( " X \u2502" ); // display "X" on game board if the bool is true. 
								sum1 = sum1 + col + 1; // add column sums and continuously updating. 
							}
                            else Write( "   \u2502" );
                        }
                        
                        for( int col = 0; col < boardSize; col ++)
                        {
							if( hiddenBoard[row, col] == true)
							hidden1 = hidden1 + col + 1;  
						}
						
                        WriteLine( "{0:d2} {1:d2} ", sum1, hidden1 ); // display sums stored in variable. 

                        if( row < boardSize - 1 )
                        {
                            Write( "        \u251c" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "\u2500\u2500\u2500\u253c" );
                            WriteLine( "\u2500\u2500\u2500\u2524" );
                        }
                        else
                        {
							
                            Write( "        \u2514" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "\u2500\u2500\u2500\u2534" );
                            WriteLine( "\u2500\u2500\u2500\u2518" );
                            
                            Write( "         " );
							for( int col = 0; col < boardSize; col ++ )
							{
								Write( " {0:d2} ", userColSums[col]); // display userBoard sums. 
							}
							WriteLine( );
							
						
							Write( "         " );
							for( int col = 0; col < boardSize; col ++ )
							{
								Write( " {0:d2} ", hiddenColSums[col]); // display hiddenBoard sums. 
							
							}
							WriteLine( );
						}
                    }
                }
                else // ! useBoxDrawingChars - similar to when useBoxDrawingChars == true 
                {
                    for( int row = 0; row < boardSize; row ++ )
                    {
                        if( row == 0 )
                        {
                            Write( "        " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( "  {0} ", letters[ col ] );
                            WriteLine( );

                            Write( "        " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( " {0,2} ", col + 1 );
                            WriteLine( );

                            Write( "        +" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "---+" );
                            WriteLine( "---+" );
                        }

                        Write( "   {0} {1,2} |", letters[ row ], row + 1 );
                        
                        int sum1 = 0;
                        int hidden1 = 0;

                        for( int col = 0; col < boardSize; col ++ )
                        {
                            if( userBoard[row, col] == true ) 
                            {
								Write( " X |" );
								sum1 = sum1 + col + 1;
							} else  {                    
								Write( "   |" );
							}
						}
							
						for( int col = 0; col < boardSize; col ++)
                        {
							if( hiddenBoard[row, col] == true)
							hidden1 = hidden1 + col + 1;  
						}
                        
                        WriteLine( "{0:d2} {1:d2} ", sum1, hidden1 ); 

                        if( row < boardSize - 1 )
                        {
                            Write( "        +" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "---+" );
                            WriteLine( "---+" );
                        }
                        else
                        {
                            Write( "        +" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "---+" );
                            WriteLine( "---+" );
                           
                            Write( "         " );
                            for( int col = 0; col < boardSize; col ++ )
                            {
								Write( " {0:d2} ", userColSums[col]); 
                            }
                            WriteLine( );

                            Write( "         " );
                            for( int col = 0; col < boardSize; col ++ )
                            {
								Write( " {0:d2} ", hiddenColSums[col]);  
							}
                            WriteLine( );
                        }
                    }
                } 
               		
				bool equal = true; // variable to check if userBoard and hiddenBoard matches. 
					
				for( int row = 0; row < boardSize; row ++) 
				{
					for( int col = 0; col < boardSize; col ++) 
					{
						if( userBoard[row, col] != hiddenBoard[row, col] ) equal = false; 
					}
				}
					
				if( equal == true) 
				{
					gameNotQuit = false; // exits while loop and quits game. 
					WriteLine(     "   "  ); 
					WriteLine(     "   Congrats! You have won the game!" ); 
				}
				else
				{
					// Get the next move.

					WriteLine( );
					WriteLine( "   Toggle cells to match the row and column sums." );
					Write(     "   Enter a row-column letter pair or 'quit': " );
					string response = ReadLine( );

					if( response == "quit" ) gameNotQuit = false;
					else
					{
						if(response.Length == 2) 
						{
							// Update the game state based on the user's response.
							// Anything invalid can just be quietly ignored.
						
							string rowPick = response.Substring(0, 1); // take first character of response as own string.
							string colPick = response.Substring(1, 1); 
						
							int rowNum = Array.IndexOf(letters, rowPick);
							int colNum = Array.IndexOf(letters, colPick);
							
							int[ ] userRowSums = new int[boardSize]; 
							// int[ ] userColSums = new int[boardSize]; previously defined in initialization section. 
						
							if((rowNum >= 0 && rowNum < boardSize) && (colNum >= 0 && colNum < boardSize)) 
							{
								if(userBoard[rowNum, colNum] == true) 
								{
									userBoard[rowNum, colNum] = false; 
									userRowSums[rowNum] -= colNum + 1; 
									userColSums[colNum] -= rowNum + 1; 
								}
								else 
								{
									userBoard[rowNum, colNum] = true; 
									userRowSums[rowNum] += colNum + 1; 
									userColSums[colNum] += rowNum + 1; 
							 
								}
							}
						}
					}
                }
            }
            
            WriteLine( );
        }
    }
}
