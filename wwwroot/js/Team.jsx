export function Team(props) {
    let { seasonTeamID } = window.ReactRouterDOM.useParams();
    const [team, setTeam] = React.useState({ team: null });

    React.useEffect(() => {

    });

    console.log("here");

    return (
        <div>{seasonTeamID}</div>
    );
}