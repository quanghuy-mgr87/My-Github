import React from 'react'
//CSS
import "../Style/MiniBookProject.css"
import { bookList } from './books'
import Book from './Book'
import { greeting } from '../Testing/Testing'

/*
*/

// const names = ['John', 'Peter', 'Susan']
// const newName = names.map(x => {
//     return <h1>{x}</h1>
// })
// console.log(newName);
// const author = "Robert F. Kennedy Jr.";
// const title = "The Real Anthony Fauci: Bill Gates, Big Pharma, and the Global War on Democracy and Public Health (Children’s Health Defense)";
// const img = "https://images-na.ssl-images-amazon.com/images/I/71M4abh-afL._AC_UL254_SR254,254_.jpg";

const MiniBookProject = () => {
    console.log(greeting);
    return (
        <section className="bookList">
            {
                bookList.map((book, index) => {
                    // const { img, title, author: { name, age } } = book;
                    return (
                        <Book key={index} {...book} />
                    )
                })
            }
        </section>
    )
}



// const Image = () => {
//     return <img src="https://images-na.ssl-images-amazon.com/images/I/71M4abh-afL._AC_UL254_SR254,254_.jpg" alt="" />
// }

// const Title = () => <h1>The Real Anthony Fauci: Bill Gates, Big Pharma, and the Global War on Democracy and Public Health (Children’s Health Defense)</h1>

// const Author = () => <h4 style={{ color: '#617d98', fontSize: '0.75 rem', marginTop: '0.25 rem' }}>Robert F. Kennedy Jr.</h4>

export default MiniBookProject
