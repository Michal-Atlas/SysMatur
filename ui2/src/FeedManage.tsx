import './FeedManage.css';
import React from "react";
import axios from "axios";
import {FeedBase} from "./Classes/FeedModel";

const FeedManage = () => {
    const [feeds, SetFeeds] = React.useState<FeedBase[]>([]);
    const [affirm, SetAffirm] = React.useState(false);
    const [newFeed, SetNewFeed] = React.useState({id: Date.now()%2147483647, name: "", url: "", visible: true, apiType: 0});
    React.useEffect(()=>{
        axios.get<FeedBase[]>('/Feed').then(res => SetFeeds(res.data)).catch(console.error);
    },[]);
console.log(newFeed.id);
    function DeleteFeed(feedId: number){
        axios.delete("/Feed", {params: {feedId: feedId}}).then(()=> document.location.reload()).catch(console.error);
    }
    function AddFeed(){
        switch (newFeed.apiType) {
            case 0:
                axios.post("/Feed/Rss", newFeed).then(() => document.location.reload()).catch(console.error)
                break;
        }
    }
    return <div className={"FeedManage"}>
            <a className={'back-button btn btn-primary'} href={"/"}>Back</a>
            <br/><br/>
            <table className={'table'}>
                <thead>
                <th scope='col'>Name</th>
                <th>Url</th>
                <th>Visibility</th>
                </thead>
                <tbody>
                {feeds.map(feed =>
                    <tr key={feed.id}>
                        <td>{feed.name}</td>
                        <td>{feed.url}</td>
                        <td><input type={"checkbox"} defaultChecked={feed.visible} onChange={(event) =>axios.patch("/Feed/Visibility", {},{params: {feedId: feed.id, visibility: event.target.checked}})}/></td>
                        <td><button onClick={() => { affirm ? DeleteFeed(feed.id) : SetAffirm(true) } } className={'btn '+(affirm ? 'btn-warning':'btn-danger')}>{affirm?'SURE?':'DELETE'}</button></td>
                    </tr>
                )}
                <tr>
                    <td><input className={'form-control'} onChange={(event)=>{SetNewFeed({...newFeed, name: event.target.value})}} type="text" name='name'/></td>
                    <td><input className={'form-control'} onChange={(event)=>{SetNewFeed({...newFeed, url: event.target.value})}} type="text" name='url'/></td>
                    <td><select name={"apiType"}><option value={0}>RSS</option></select></td>
                    <td><input onClick={AddFeed} className='btn btn-primary' type='button' value='CREATE'/></td>
                </tr>
                </tbody>
            </table>
    </div>
}

export default FeedManage;