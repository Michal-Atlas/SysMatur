import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App.tsx';
import reportWebVitals from './reportWebVitals';
import {Route} from "react-router";
import {BrowserRouter} from "react-router-dom";
import Profile from "./Profile";
import Logon from "./Logon";
import FeedManage from "./FeedManage";
import 'bootstrap/scss/bootstrap.scss';

ReactDOM.render(
    <><table className="Name">
        <tr>
            <th><h1>SysMatur</h1></th>
        </tr>
    </table>
    <BrowserRouter>
        <React.StrictMode>
            <Route exact path='/' component={App}/>
            <Route path='/profile' component={Profile}/>
            <Route path={'/logon'} component={Logon}/>
            <Route path={'/feedsmanage'} component={FeedManage}/>
        </React.StrictMode>
    </BrowserRouter></>,
    document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
