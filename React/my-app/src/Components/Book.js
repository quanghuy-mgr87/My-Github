import React from 'react'

// const Book = ({ img, title, author: { name, age }, children }) => {
const Book = ({ img, title, author: { name, age }, children }) => {
    // const { img, title, author: { name, age }, children } = props
    // console.log(props);

    //attribute, eventHandler
    //onClick, onMouseOver
    const clickHandler = () => {
        alert('Hello world')
    }

    const complexExample = (author) => {
        alert(author)
    }

    return <article className="book">
        {/* <Image></Image>
            <Title></Title>
            <Author></Author> */}
        <img src={img} alt="" />
        {/* {children} */}
        <h1>{title}</h1>
        <h4>{name}</h4>
        <h4>{age}</h4>
        {/* <button type="button" onClick={clickHandler}>Click</button> */}
        <button type="button" onClick={() => complexExample(name)}>More complex</button>
        {/* <button type="button" onClick={() => {
                alert(title)
            }}>Click</button> */}
        {/* <p>{let x = 6}</p> */}
        {/* <p>{6 + 6}</p> */}
    </article>
}

export default Book
