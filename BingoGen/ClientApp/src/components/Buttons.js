import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faImage } from '@fortawesome/free-solid-svg-icons';

export default props => (
  <div className='buttons fadein'>
    <div className='button'>
      <label htmlFor='single' style={{ cursor: 'pointer' }}>
        <FontAwesomeIcon icon={faImage} color='#3B5998' size='5x' />
      </label>
      <input type='file' id='single' onChange={props.onChange} hidden />
    </div>
  </div>
);
