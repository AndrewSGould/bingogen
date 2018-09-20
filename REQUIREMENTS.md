# BingoGen Requirements/Ideas

Slap in a set of 50-100 things.

Using a seed, RNG your way to pull 25 things from the bag and spit out a board.

Provide a field for the seed and let users put in their usernames.

Bonus: Add optional image URLs for each item in the board.

Bonus: Add an optional "free space" item and force it to be in the center.

Bonus: Add optional difficulty weights (0-1], defaulting to 0.5 if unspecified, and a difficulty option for the generation of the card. Every time you generate a board, check the 12 BINGO lines and determine the minimum difficulty (since you only need 1 line to get a BINGO) and the average difficulty (since traditional bingo is won by being the first to complete a line, time matters). Difficulty is simply 1 minus the product of the weights in the line. Something that's a 1 is essentially a free space, for example. Something that's almost 0 will almost certainly not happen. A line of all 1s is a guaranteed win and has a difficulty of 0. A line of all .01s is almost guaranteed not to happen and has a difficulty of 0.99999 or 99.999%.

If the minimum difficulty (completion difficulty) of the generated board is far from the desired setting (how far is too far?), regenerate the board. Do the same if the average difficulty is too far off. Or, generate 10 boards in a row and pick the one that most closely matches the desired difficulty.