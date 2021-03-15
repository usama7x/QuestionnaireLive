import React, {useEffect, useState, Fragment} from 'react';
import Question from './question';
import {Button, Input, Spin, Space} from 'antd';

export const Questionnaire = props => {
    const [questions, setQuestions] = useState();
    const [answers, setAnswers] = useState({});
    const [user, setUser] = useState();
    const [isLoading, setLoader] = useState(true);
    const apiUrl = 'https://localhost:5001/api/questions';

    useEffect(() => {
        fetch(apiUrl)
        .then(res => res.json()
        .then(body => {
        setLoader(false);
        setQuestions(body);
        }))
        .catch(err => console.log(err))
    }, []);

    const handleClick = async e => {
        const requestModel = {answers, name: user};
        const requestOptions = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(requestModel)
        }
       await (await fetch(apiUrl, requestOptions)).json().then(body => console.log(body));
    }

    return questions ? 
        <Fragment>
            <Input 
                onChange={e => setUser(e.target.value)} 
                placeholder={'Name'} style={{width: 200}}
            />
            <br/>
            <br/>
             {questions?.map(q => 
                <Question key={q.questionId} data={q} setAnwsers={setAnswers}/>)}
            <Button onClick={handleClick} size={'large'}>Submit</Button>
        </Fragment>
        :  
        <Space size="middle">
            <Spin spinning={isLoading} />
        </Space>     
}
