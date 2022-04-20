import React from 'react'

function NestedComponentsAndTools() {
    return (
        <div>
            <Person />
            <Message />
        </div>
    )
}

const Person = () => <h2>Huy Nguyen</h2>
const Message = () => {
    return <p>This is my message</p>
}

export default NestedComponentsAndTools
