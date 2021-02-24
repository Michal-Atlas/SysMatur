import React, {useState} from "react";
import {useAuth0} from "@auth0/auth0-react";

const AddFeed = () => {
    const [address, setAddress] = useState();
    const {user, isAuthenticated, isLoading} = useAuth0();
    return (<form>
        <label htmlFor="address">Address:</label><br/>
        <input type="text" id="address" name="address" onChange={() => setAddress("bbci.co.uk")}/>
        <input type="button" value="Submit" onClick={() => callAddFeed(user)}/></form>);
};

const callAddFeed = async (user) => {
    alert("Called");
    const request = await fetch('Feeds/Add', {
        method: 'POST',
        body: JSON.stringify({address: "this.address", sub: 20})
    });
    alert("Success");
}

export default AddFeed;
