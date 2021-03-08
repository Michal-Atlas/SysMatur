import React from 'react';
import axios from "axios";
import $ from 'jquery';

const RSS = () => {
    const [feed, SetFeed] = React.useState("");
    React.useEffect(()=>{
        axios.get("").then(
            res => SetFeed(res.data)
        ).then(()=>{
        }).catch(console.error);
    },[]);
    
    return(
        <p>{feed}</p>
    );
}

export default RSS;
