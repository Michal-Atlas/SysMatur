import Cookies from "universal-cookie";
import {useHistory} from "react-router";
import "./Logon.css";
import {ProfileModel} from "./Classes/ProfileModel";
import React from "react";
import axios from "axios";
import bcrypt from 'bcryptjs';

const Logon = () => {
    const cookie = new Cookies();
    const history = useHistory();

    if (cookie.get("sessionKey")) {
        console.log("logged in");
        history.push("/");
    }

    const [user, SetUser] = React.useState<ProfileModel>({username: "", email: ""});
    const [password, SetPassword] = React.useState("");

    return <div className={"Logon"}>
        <input type={"text"} name={"username"} placeholder={"Username"} value={user.username}
               onChange={(event) => SetUser({username: event.target.value, email: user.email})}/>
        <input type={"password"} name={"password"} placeholder={"Password"} value={password}
               onChange={(event) => SetPassword(event.target.value)}/>
        <button type={"submit"} onClick={SubmitLogon}>Logon</button>
        <br/><br/>
        <hr/>
        <br/>
        <input type={"text"} name={"email"} placeholder={"E-Mail"} value={user.email}
               onChange={(event) => SetUser({username: user.username, email: event.target.value})}/>
        <button type={"submit"} onClick={SubmitRegister}>Register</button>
    </div>;

    async function SubmitLogon() {
        const salt = await GetSalt();
        if (!salt) {
            return;
        }
        const hash = bcrypt.hashSync(password, salt);
        axios.post("/Auth", {}, {
            params: {
                username: user.username,
                passwordHash: hash
            }
        }).then(() =>
            document.location.reload()
        ).catch(console.error);
    }

    function SubmitRegister(event: any) {
        const salt = bcrypt.genSaltSync(10);
        const hash = bcrypt.hashSync(password, salt);
        axios.post("/User", user, {
                params: {
                    passwordHash: hash,
                    passwordSalt: salt,
                }
            }
        ).then().catch(console.error);
        SubmitLogon().then();
    }

    async function GetSalt(): Promise<string | void> {
        return await axios.get<string>("/User/salt", {params: {userName: user.username}}).then(result => {
            return result.data
        }).catch(console.error);
    }
}

export default Logon;