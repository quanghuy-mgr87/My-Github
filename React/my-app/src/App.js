// import JSXRules from './Components/JSXRules'
// import NestedComponentsAndTools from './Components/NestedComponentsAndTools'
// import MiniBookProject from './Components/MiniBookProject'
import './App.css';
import { BrowserRouter as Router, Route, Link, Routes } from 'react-router-dom'
import react from 'react';

const Home = () => <h1>Home</h1>
const About = () => <h1>About</h1>
const Contact = () => <h1>Contact</h1>

function App() {
  return (
    <div>
      {/* <JSXRules></JSXRules> */}
      {/* <NestedComponentsAndTools></NestedComponentsAndTools> */}
      {/* <MiniBookProject></MiniBookProject> */}
      <Router>
        <div>
          <nav>
            <ul>
              <li>
                <Link to="/">Home</Link>
              </li>
              <li>
                <Link to="/about">About</Link>
              </li>
              <li>
                <Link to="/contact">Contact</Link>
              </li>
            </ul>
          </nav>

          <hr />


          <Routes>
            <Route path="/" exact component={Home}>
            </Route>
            <Route path="/about" exact component={About}>
            </Route>
            <Route path="/contact" exact component={Contact}>
            </Route>
          </Routes>

        </div>
      </Router>
    </div>
  );
}

export default App;
