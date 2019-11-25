import React, { Component } from 'react';
import Spinner from './Spinner';
import Images from './Images';
import Buttons from './Buttons';
import { post, get } from 'axios';

// TODO: Make this number 50, when you do why does the 'than or equal to' not seem to work?
const MINIMUM_PREDICTIONS_NEEDED = 49;

export class Prediction extends Component {
  static displayName = Prediction.name;

  constructor(props) {
    super(props);
    this.state = {
      currentCount: 0,
      readyColor: 'red', //TODO: This name sucks. Also, reimplement color change when enough predictions have been added
      uploading: false,
      prediction: '',
      difficulty: 3,
      image: []
    };

    this.handleChange = this.handleChange.bind(this);
    this.testGet = this.testGet.bind(this);
  }

  async submit(e) {
    e.preventDefault();

    this.setState({ uploading: true });

    //TODO: dont hardcode the url
    const url = `https://localhost:5001/imageupload`;
    const formData = new FormData();
    const config = {
      headers: {
        'content-type': 'multipart/form-data'
      }
    };

    //TODO: when creating first prediction, we need to create a board and use that to keep track of amount of predictions

    formData.append('image', this.state.file);
    formData.append('predictionText', this.state.prediction);
    formData.append('difficulty', this.state.difficulty);

    return post(url, formData, config)
      .then(response => {
        this.setState({
          uploading: false
          //currentCount: currentCount++
        });
      })
      .catch(error => {
        console.log(error);
        this.setState({ uploading: false });
      });
  }

  // TODO: why does this break with normal function syntax? is it because of `this` scope?
  onChange = e => {
    this.setState({
      image: URL.createObjectURL(e.target.files[0]),
      file: e.target.files[0]
    });
  };

  removeImage = () => {
    this.setState({
      image: []
    });
  };

  handleChange(e) {
    this.setState({ prediction: e.target.value });
  }

  testGet() {
    get('https://localhost:5001/get')
      .then(function(response) {
        console.log(response);
      })
      .catch(function(error) {
        console.log(error);
      });
  }

  render() {
    // TODO: UI is ugly
    // TODO: Also create and send difficulty
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
        <h1>Board Creation</h1>

        <label htmlFor='prediction'>Prediction</label>
        <input
          type='text'
          id='prediction'
          value={this.state.prediction}
          onChange={this.handleChange.bind(this)}
        />
        <span style={{ color: this.state.readyColor }}>
          {this.state.currentCount}
        </span>
        <span>
          {' '}
          / 50 (you must create at least 50 predictions before a board can
          generate cards)
        </span>

        <div>
          <label htmlFor='difficulty'>Likelihood</label>
          <select
            name='difficulty'
            id='difficulty'
            onChange={e => this.setState({ difficulty: e.target.value })}
          >
            <option value=''>--How likely is this to happen?--</option>
            <option value='5'>Very Unlikely</option>
            <option value='4'>Unlikely</option>
            <option value='3'>I don't like to make decisions</option>
            <option value='2'>Likely</option>
            <option value='1'>Very Likely</option>
          </select>
        </div>

        <div className='buttons'>{content()}</div>

        <button type='submit' className='btn btn-primary'>
          Add
        </button>

        <div>
          <button type='button' onClick={this.testGet}>
            Test Get
          </button>
        </div>
      </form>
    );
  }
}
