import React from 'react'

const data = [
    { id: 1, name: 'john' },
    { id: 2, name: 'peter' },
    { id: 3, name: 'susan' },
    { id: 4, name: 'anna' }
]

const UseStateArray = () => {
    const [people, setPeople] = React.useState(data);
    const removeItem = (id) => {
        let newPeople = people.filter(x => x.id !== id)
        setPeople(newPeople)
    }
    return (
        <div>
            {people.map((person) => {
                const { id, name } = person;
                return <div key={id}>
                    <h4>{name}</h4>
                    <button onClick={() => removeItem(id)}>Remove</button>
                </div>
            })}
            {/* <button onClick={() => setPeople([])}>Clear items</button> */}
        </div>
    )
}

export default UseStateArray
