import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import {Home} from './components/Home';

import './custom.css'
import {PrintUsers} from "./components/PrintUsers";
import Profile from "./components/Profile";
import {Feeds} from "./Feeds";
import RSS from "./components/RSS";

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home}/>
                <Route path='/print-users' component={PrintUsers}/>
                <Route path='/profile' component={Profile}/>
                <Route path='/feeds' component={Feeds}/>
                <Route path='/rss' component={RSS}/>
            </Layout>
        );
    }
}
