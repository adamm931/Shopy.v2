import React from 'react';
import { AuthUtils } from '../../Utils/AuthUtils';

const Header: React.FC = () => (
    <nav className="navbar navbar-dark fixed-top bg-dark flex-md-nowrap p-0 shadow">
        <a className="navbar-brand col-sm-3 col-md-2 mr-0" href="#">Admim portal</a>
        <ul className="navbar-nav px-3">
            <li className="nav-item text-nowrap">
                <a className="nav-link logout" onClick={AuthUtils.Logout}>Sign out</a>
            </li>
        </ul>
    </nav>
)


export default Header