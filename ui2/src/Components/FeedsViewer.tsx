import './FeedsViewer.css';
import Post from './Post';
import React from "react";
import axios from "axios";
import {PostModel} from "../Classes/PostModel";
import {FeedBase} from "../Classes/FeedModel";

const FeedsViewer = (props: { feeds: FeedBase[] }) => {
    const [posts, SetPosts] = React.useState<{ feedName: string, post: PostModel }[]>([]);
    React.useEffect(() => {
            props.feeds.forEach(feed => {
                if (feed.visible) {
                    axios.get<PostModel[]>("/FeedRss", {params: {url: feed.url}}).then(
                        result => {
                            SetPosts(p =>
                                [
                                    ...p,
                                    ...result.data.map(d => {
                                        return {feedName: feed.name, post: d}
                                    })
                                ]);

                            console.log(feed.name, posts.length)
                        })
                        .catch(console.error);
                }
            });
            SetPosts(p => p.sort((a, b) => +b.post.date - (+a.post.date)));
        }
        , [props.feeds]);
    return (
        <>
            {
                posts.length !== 0 ?
                    posts.map((p: { feedName: string, post: PostModel }) => <Post key={p.post.date} post={p.post}
                                                                                  feed={p.feedName}/>)
                    : <div className="Loading"><b>"No Feeds or Loading..."</b></div>
            }
        </>
    );
}

export default FeedsViewer;