import React, {Component} from 'react';

export class PrintUsers extends Component {
    static displayName = PrintUsers.name;

    constructor(props) {
        super(props);
        this.state = {users: [], loading: true};
    }

    static renderUserTable(users) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                </tr>
                </thead>
                <tbody>
                {users.map(user =>
                    <tr key={user.id}>
                        <td>{user.id}</td>
                        <td>{user.displayName}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    componentDidMount() {
        this.populateUserData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : PrintUsers.renderUserTable(this.state.users);

        return (
            <div>
                <h1 id="tabelLabel">Users</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateUserData() {
        const response = await fetch('Users/All');
        const data = await response.json();
        this.setState({users: data, loading: false});
    }
}
