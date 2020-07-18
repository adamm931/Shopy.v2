import React from 'react'
import Main from '../Main/Main'
import Sidebar from '../Sidebar/Sidebar'
import Footer from '../Footer/Footer'

const Body: React.FC = () => (
    <div className="container-fluid main-container">
        <div className="row">
            <Sidebar />
            <Main />
        </div>
        <Footer />
    </div>
)

export default Body