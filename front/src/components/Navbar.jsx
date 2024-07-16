import logo from '../../src/assets/logo.png';
import circleUserSolid from '../../src/assets/circle-user-solid.svg';
import { Link } from 'react-router-dom';
import '../../src/styles/Navbar.css';

export default function Navbar() {
    return (
        <div id='navbar-flex'>
            <nav id='navbar'>
                <div id='navbar-middle'>
                    <Link className='middle-nav' to='/'>
                        <img src={logo} alt="magnifying glass" />
                        <h1>DateFinder</h1> 
                    </Link>
                </div>
                <div id='navbar-right'>
                    <img src={circleUserSolid} alt="user icon" />
                </div>
            </nav>
        </div>

    );
}

