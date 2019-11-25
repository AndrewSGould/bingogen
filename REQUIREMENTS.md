# BingoGen Requirements/Ideas

## Get a set of 50-100 things

### Add 'free space' (optional), force it to center

### Allow crowd-sourced boards

#### Allow image URLs for each item

#### Generate the text

### Pull 25 things for a board

#### For the board, generate a seed and allow someone to put in a username

Bonus: Add optional difficulty weights (0-1], defaulting to 0.5 if unspecified, and a difficulty option for the generation of the card. Every time you generate a board, check the 12 BINGO lines and determine the minimum difficulty (since you only need 1 line to get a BINGO) and the average difficulty (since traditional bingo is won by being the first to complete a line, time matters). Difficulty is simply 1 minus the product of the weights in the line. Something that's a 1 is essentially a free space, for example. Something that's almost 0 will almost certainly not happen. A line of all 1s is a guaranteed win and has a difficulty of 0. A line of all .01s is almost guaranteed not to happen and has a difficulty of 0.99999 or 99.999%.

If the minimum difficulty (completion difficulty) of the generated board is far from the desired setting (how far is too far?), regenerate the board. Do the same if the average difficulty is too far off. Or, generate 10 boards in a row and pick the one that most closely matches the desired difficulty.

# Terms

- Board - A collection of Bingo Cards
- Card - An individual bingo board
- Predictions - A square in a Bingo card. Consists of text, an image, and difficulty weight

# Tasks

- 'Prediction Input Counter' control
- - Initial state 0 / 50 (50 being the minimum amount of Predics needed to generate a card)
- - When the number is lower than the threshold, make the left number red
- - When the number is higher than the threshold, make the left number green

- 'Prediction' control
- - Alphanumeric only
- - Each prediction gets assigned to a Card
- - Each prediction increase the Prediction Input Counter
- - Maximum Length (based off of how much text we can fit on a card)
- - Do not allow more than 100 Predics (disable add button?)

- Difficulty control
- - Single-choice control
- - Values are Very Hard, Hard, Neutral, Easy, Very Easy (debatable)
- - These difficulties will effect the 'weight' of a card (how hard it is to finish)

- Image uploader control
- - Allow the user to use images in their bingo board
- - For now, do not allow upload, only references
- - Auto-scale any linked images down to the required size

- Bingo 'Board'
- - Allow creation of the card at any time
- - Boards live for 1 year max, allow user to choose board life?
- - - If the card has not met the minimum Predictions, put the card in a 'crowdsourced' state and set it to not active
- - - If the card has met the minimum predictions, put the card into an active state
- - - - Allow the user to still allow to put it into a 'crowdsourced' state
- - - - If a deck is not active, do not allow it to generate cards
- - - - Once cards are generated, do we allow any more additions? Would throw the difficulty scale off
