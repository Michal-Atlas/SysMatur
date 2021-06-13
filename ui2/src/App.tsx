import './App.css';
import SideBar from "./Components/SideBar";
import FeedsViewer from "./Components/FeedsViewer";
import {FeedBase} from "./Classes/FeedModel";
import React from "react";
import axios from "axios";

const App = () => {
    const [feeds, SetFeeds] = React.useState<FeedBase[]>([]);
    React.useEffect(() => {
            axios.get<FeedBase[]>("/Feed").then(result => {
                SetFeeds(result.data)
            }).catch(console.error);
        }
        , []);
    return (
        <>
            <table className="Name">
                <tr>
                    <th><h1>SysMatur</h1></th>
                </tr>
            </table>
            <SideBar feeds={feeds}/>
            <br/><br/><br/>

            <FeedsViewer feeds={feeds}/>
        </>
    );
}

export default App;
