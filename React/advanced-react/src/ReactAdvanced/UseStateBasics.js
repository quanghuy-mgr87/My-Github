import React, { useState } from 'react'

const UseStateBasics = () => {
    // console.log(useState('Hello world'));
    // const value = useState(1)[0]
    // const handler = useState(1)[1]
    // console.log(value, handler);
    const [text, setText] = useState('random title')
    const handleClick = () => {
        if (text === 'random title') {
            setText('new title')
        }
        else{
            setText('random title')
        }
    }
    return (
        <React.Fragment>
            <h1>{text}</h1>
            <button onClick={handleClick}>Change title</button>
        </React.Fragment>
    )
}

export default UseStateBasics

