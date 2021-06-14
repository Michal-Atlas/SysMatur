import './SideBar.css';
import {FeedBase} from "../Classes/FeedModel";
import {Link} from "react-router-dom";
import Cookies from "universal-cookie";
import {Button} from "react-bootstrap";
import axios from "axios";
import React from "react";

const SideBar = (props: { feeds: FeedBase[] }) => {
    const cookies = new Cookies();
    return (
        <div className="SideBar">
            <h1>Settings</h1>
            <h4>Show feeds:</h4>
            {
                props.feeds.map((f: FeedBase) =>
                    <>
                        <input type={"checkbox"} defaultChecked={f.visible} onChange={(event) =>{axios.patch("/Feed/Visibility", {},{params: {feedId: f.id, visibility: event.target.checked}});document.location.reload()}}/>
                        <label htmlFor="fb">{f.name}</label>
                        <br/>
                    </>
                )
            }

            <br/>
            <Link to={"/feedsmanage"}><Button>Manage Feeds</Button></Link>
            <br/>
            <br/>
            <Link to={"/profile"}><Button>Edit Profile</Button></Link>
            <Button onClick={() => {cookies.remove("sessionKey"); document.location.reload();}}>Log out</Button>
        </div>
    );
}

export default SideBar;