import React, { Component } from 'react';
import Spinner from './Spinner';
import Images from './Images';
import Buttons from './Buttons';
import { post } from 'axios';

const MINIMUM_PREDICTIONS_NEEDED = 49;

const toastColor = {
  background: '#505050',
  text: '#fff'
};

export class Prediction extends Component {
  static displayName = Prediction.name;

  constructor(props) {
    super(props);
    this.state = {
      currentCount: 0,
      readyColor: 'red',
      uploading: false,
      image: []
    };

    this.incrementCounter = this.incrementCounter.bind(this);
  }

  async submit(e) {
    e.preventDefault();

    this.setState({ uploading: true });

    const url = `https://localhost:5001/imageupload`;
    const formData = new FormData();
    formData.append('body', this.state.file);
    const config = {
      headers: {
        'content-type': 'multipart/form-data'
      }
    };
    return post(url, formData, config)
      .then(response => {
        console.log(response);
      })
      .catch(error => {
        console.log(error);
      });
  }

  onChange = e => {
    this.setState({
      image: URL.createObjectURL(e.target.files[0]),
      file: e.target.files[0]
    });
  };

  removeImage = () => {
    this.setState({
      image: ''
    });
  };

  incrementCounter() {
    this.setState({ currentCount: this.state.currentCount + 1 });

    if (this.state.currentCount >= MINIMUM_PREDICTIONS_NEEDED)
      this.setState({ readyColor: 'green' });
  }

  render() {
    const { uploading, image } = this.state;

    const content = () => {
      switch (true) {
        case uploading:
          return <Spinner />;
        case image.length > 0:
          return <Images image={image} removeImage={this.removeImage} />;
        default:
          return <Buttons onChange={this.onChange} />;
      }
    };

    return (
      <form onSubmit={e => this.submit(e)}>
        <h1>Card Creation</h1>
        <div>
          <label htmlFor='prediction'>Prediction</label>
          <input type='text' id='prediction' />
          <span style={{ color: this.state.readyColor }}>
            {this.state.currentCount}
          </span>
          <span> / 50</span>
        </div>

        <div>
          <div className='buttons'>{content()}</div>
        </div>

        <button
          type='submit'
          className='btn btn-primary'
          onClick={this.incrementCounter}
        >
          Add
        </button>
      </form>
    );
  }
}
