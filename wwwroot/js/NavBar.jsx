export function NavBar(props) {
    return (
        <ReactBootstrap.Nav activeKey="/home" onSelect={(selectedKey) => alert(`selected ${selectedKey}`)}>
            <ReactBootstrap.Nav.Item>
                <ReactBootstrap.Nav.Link as={window.ReactRouterDOM.Link} to="/">Home</ReactBootstrap.Nav.Link>
            </ReactBootstrap.Nav.Item>
            <ReactBootstrap.Nav.Item>
                <ReactBootstrap.Nav.Link as={window.ReactRouterDOM.Link} to="/events">Schedule</ReactBootstrap.Nav.Link>
            </ReactBootstrap.Nav.Item>
            <ReactBootstrap.Nav.Item>
                <ReactBootstrap.Nav.Link disabled>Stats</ReactBootstrap.Nav.Link>
            </ReactBootstrap.Nav.Item>
        </ReactBootstrap.Nav>
    );
}