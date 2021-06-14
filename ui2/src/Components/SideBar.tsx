import './SideBar.css';
import {FeedBase} from "../Classes/FeedModel";
import {Link} from "react-router-dom";
import Cookies from "universal-cookie";

const SideBar = (props: { feeds: FeedBase[] }) => {
    const cookies = new Cookies();
    return (
        <div className="SideBar">
            <h1>Settings</h1>
            <h4>Show feeds:</h4>
            {
                props.feeds.map((f: FeedBase) =>
                    <>
                        <input type="checkbox" id="fb" value={f.id} checked={f.visible}/>
                        <label htmlFor="fb">{f.name}</label>
                        <br/>
                    </>
                )
            }


            <button>Set</button>
            <br/>
            <button>Add feed</button>
            <br/>
            <br/>
            <Link to={"/profile"}><button>Edit Profile</button></Link>
            <button onClick={() => {cookies.remove("sessionKey"); document.location.reload();}}>Log out</button>
        </div>
    );
}

export default SideBar;