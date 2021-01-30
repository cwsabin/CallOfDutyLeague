export function NavBar(props) {
    return (
        <ReactBootstrap.Nav activeKey="/home" onSelect={(selectedKey) => alert(`selected ${selectedKey}`)}>
            <ReactBootstrap.Nav.Item>
                <ReactBootstrap.Nav.Link as={window.ReactRouterDOM.Link} to="/">Home</ReactBootstrap.Nav.Link>
            </ReactBootstrap.Nav.Item>
            <ReactBootstrap.Nav.Item>
                <ReactBootstrap.Nav.Link eventKey="link-1">Link</ReactBootstrap.Nav.Link>
            </ReactBootstrap.Nav.Item>
            <ReactBootstrap.Nav.Item>
                <ReactBootstrap.Nav.Link eventKey="link-2">Link</ReactBootstrap.Nav.Link>
            </ReactBootstrap.Nav.Item>
            <ReactBootstrap.Nav.Item>
                <ReactBootstrap.Nav.Link eventKey="disabled" disabled>Disabled</ReactBootstrap.Nav.Link>
            </ReactBootstrap.Nav.Item>
        </ReactBootstrap.Nav>
    );
}