import React from 'react';
import { Checkbox , Input } from 'antd';
import 'antd/dist/antd.css';

const Question = props => {
    const {data, setAnwsers} = props;
    const onChange = (checkedValues, questionId) => {
      debugger
      setAnwsers(prev => ({
        ...prev,
        [questionId]: checkedValues
      }))
      }      
    return (
        <div>
        <h4>{`${data.questionId}. ${data.question}`}</h4>
        <Checkbox.Group 
          onChange={e => onChange(e, data.questionId)}
          options={data.options.map(o => ({label: o.optionStatement, value: o.optionId}))}
          ></Checkbox.Group>
        <br />
        <br />
        </div>
    );
}

export default Question;