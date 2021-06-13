import './SideBar.css';
import {FeedBase} from "../Classes/FeedModel";

const SideBar = (props: {feeds: FeedBase[]}) => {
    return (
        <div className="SideBar">
            <h1>Settings</h1>
            <h4>Show feeds:</h4>
                {
                        props.feeds.map((f: FeedBase) =>{
                <><input type="checkbox" id="fb" value={f.id}/>
                        <label htmlFor="fb">{f.name}</label><br/></>
                })
                }


            <button type="button">Set</button>
            <br/>
            <button type="button">Add feed</button>
            <br/>
            <br/>
            <button type="button">Profile</button>
            <button type="button">Log out</button>
        </div>
    );
}

export default SideBar;