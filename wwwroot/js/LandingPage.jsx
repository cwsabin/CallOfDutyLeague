import { TeamStandings } from "./TeamStandings";

function LandingPage(props) {
    return (
        <div>
            Test
            <TeamStandings />
        </div>
    );
}

ReactDOM.render(
    <LandingPage />,
    document.getElementById('content')
);