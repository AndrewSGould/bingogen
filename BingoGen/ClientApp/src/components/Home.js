import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Bingo Gen</h1>
        <p>Ideas for future me:</p>
        <ul>
          <li>On the homepage, show last 3? created Bingo Cards</li>
          <li>On the homepage, have a buy me a beer donation link</li>
          <li>On the homepage, have link to the repo</li>
          <li>
            On the homepage, explain what the site is with a youtube link?
          </li>
          <li>
            When creating a board, watermark it with the site and the creator
          </li>
          <li>
            Allow board creation with less than 50. cannot generate cards until
            then. can send out invite links for crowdsourced ideas
          </li>
        </ul>
      </div>
    );
  }
}
