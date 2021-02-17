import React, {Component} from "react";

export class Feeds extends Component {
    constructor(props) {
        super(props);
        console.log(props);
        this.state = {loading: true, feeds: []};
    }

    static renderUserTable(feeds) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Domain</th>
                </tr>
                </thead>
                <tbody>
                {feeds.map(feed =>
                    <tr key={feed.id}>
                        <td>{feed.address}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    componentDidMount() {
        this.populateData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Feeds.renderUserTable(this.state.users);

        return (
            <div>
                <h1 id="tabelLabel">Users</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateData() {
        const response = await fetch('Feeds/GetFeeds', {method: 'POST', body: JSON.stringify({sub: null})});
        const data = await response.json();
        this.setState({feeds: data, loading: false});
    }
}
