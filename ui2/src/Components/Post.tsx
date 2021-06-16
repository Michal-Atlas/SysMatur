import {PostModel} from "../Classes/PostModel";
import './Post.css';

const Post = (props: { post: PostModel, feed: string }) => {
    const post = props.post;
    return (<div className="Post"><a href={post.anchor}>
        <table>
            <tr>
                <td>@post["Username"]</td>
                <td style={{textAlign: "right"}}><p>{props.feed}</p></td>
            </tr>
            <tr>
                <td colSpan={1}>{post.date}</td>
            </tr>
            <tr>
                <td colSpan={3}>{post.summary}</td>
                <td colSpan={3}>{post.body}</td>
            </tr>
            <tr>
                <td style={{textAlign: "center"}} colSpan={3}>FOTO</td>
                {
                    post.image !== "" &&
                    <td style={{width: "5%", border: "1px solid black"}} rowSpan={2}><img alt={""} src={post.image}/></td>
                }
            </tr>
        </table>
    </a></div>);
}
export default Post;