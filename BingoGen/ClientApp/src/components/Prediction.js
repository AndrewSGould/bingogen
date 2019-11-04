import React, { Component } from 'react';
import Spinner from './Spinner';
import Images from './Images';
import Buttons from './Buttons';
import { API_URL } from './config';

const MINIMUM_PREDICTIONS_NEEDED = 49;

export class Prediction extends Component {
  static displayName = Prediction.name;

  constructor(props) {
    super(props);
    this.state = {
      currentCount: 0,
      readyColor: 'red',
      uploading: false,
      images: []
    };

    this.incrementCounter = this.incrementCounter.bind(this);
  }

  onChange = e => {
    const files = Array.from(e.target.files);
    this.setState({uploading = true});
  }

  incrementCounter() {
    this.setState({ currentCount: this.state.currentCount + 1 });

    if (this.state.currentCount >= MINIMUM_PREDICTIONS_NEEDED)
      this.setState({ readyColor: 'green' });
  }

  render() {
    return (
      <div>
        <h1>Card Creation</h1>

        <div>
          <label htmlFor='prediction'>Prediction</label>
          <input type='text' id='prediction' />
          <span style={{ color: this.state.readyColor }}>
            {this.state.currentCount}
          </span>
          <span> / 50</span>
        </div>

        <label htmlFor='image'>Image</label>
        <input type='url' id='image' />

        <button className='btn btn-primary' onClick={this.incrementCounter}>
          Add
        </button>
      </div>
    );
  }
}
