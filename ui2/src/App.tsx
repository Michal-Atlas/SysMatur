import './App.css';
import SideBar from "./Components/SideBar";
import FeedsViewer from "./Components/FeedsViewer";
import {FeedBase} from "./Classes/FeedModel";
import React from "react";
import axios from "axios";
import Cookies from "universal-cookie";
import {useHistory} from "react-router";

const App = () => {
    const cookie = new Cookies();
    const history = useHistory();
    const [feeds, SetFeeds] = React.useState<FeedBase[]>([]);
    React.useEffect(() => {
            axios.get<FeedBase[]>("/Feed").then(result => {
                SetFeeds(result.data)
            }).catch(console.error);
        }
        , []);
    if (!cookie.get("sessionKey")) {
        console.log("logged out");
        history.push("/logon");
    }
    console.log(feeds);
    return (
        <>
            <SideBar feeds={feeds}/>
            <br/><br/><br/>

            <FeedsViewer feeds={feeds}/>
        </>
    );
}

export default App;
