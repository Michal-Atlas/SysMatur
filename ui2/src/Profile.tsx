import {Link} from "react-router-dom";
import './Profile.css';
import React from "react";
import {ProfileModel} from "./Classes/ProfileModel";
import axios from "axios";

const Profile = () => {
    const [user, SetUser] = React.useState<ProfileModel>();
    React.useEffect(() => {
        axios.get("/User").then(result => SetUser(result.data)).catch(console.error);
    }, []);

    return (<div className={"Profile"}>
        {user &&
        <>
            <Link to={"/"}>Back</Link><br/><br/>
            <input type={"text"} defaultValue={user.username} onChange={(event) => SetUser({username: event.target.value, email: user.email})} />
            <input type={"text"} defaultValue={user.email} onChange={(event) => SetUser({username: user.username, email: event.target.value})} />
            <br/><br/>
            <button onClick={() => axios.patch("/User", user).catch(console.error)}>Save</button>
        </>
        }
    </div>);
}

export default Profile;