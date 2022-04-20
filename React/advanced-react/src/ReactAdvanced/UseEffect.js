import React from 'react'

const UseEffect = () => {
    const [counter, setCounter] = React.useState(0);
    const [size, setSize] = React.useState(window.innerWidth)
    const Increase = () => {
        setCounter(counter + 1)
    }

    const checkSize = () => {
        setSize(window.innerWidth)
    }

    console.log('initial');

    React.useEffect(() => {
        console.log('call useEffect');
        if (counter > 1) {
            document.title = `New Message (${counter})`
        }
    }, [counter])

    React.useEffect(() => {
        window.addEventListener("resize", checkSize)
        return () => {
            console.log('cleanup');
            window.removeEventListener("resize", checkSize)
        }
    }, [size])

    return (
        <div>
            {counter}
            <br />
            <button onClick={() => Increase()}>Increase</button>
            <h1>Window</h1>
            <p>{size}</p>
        </div>
    )
}

export default UseEffect
