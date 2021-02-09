import { getCurrentRoster, getTeam } from "./api.js";

export function Team() {
    let { seasonTeamID } = window.ReactRouterDOM.useParams();
    const [team, setTeam] = React.useState({ team: null });
    const [roster, setRoster] = React.useState([]);

    React.useEffect(() => {
        const getRoster = async () => {
            setRoster(await getCurrentRoster(seasonTeamID))
        }

        const getTeamInfo = async () => {
            setTeam(await getTeam(seasonTeamID))
        }

        getRoster()
        getTeamInfo()
    }, []);

    return (
        <ReactBootstrap.Container fluid>
            <ReactBootstrap.Row>
                <h1>{team.teamName}</h1>
            </ReactBootstrap.Row>
            <ReactBootstrap.Row>
                <ReactBootstrap.Col key="teamRoster" md='auto'>
                    <ReactBootstrap.Table striped bordered hover variant="dark" key={team.teamName}>
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            {roster.map((player) => (
                                <tr key={player.playerID}>
                                    <td>{player.gamerName}</td>
                                    <td>{player.firstName}</td>
                                    <td>{player.lastName}</td>
                                </tr>
                            ))}
                        </tbody>
                    </ReactBootstrap.Table>
                </ReactBootstrap.Col>
            </ReactBootstrap.Row>
        </ReactBootstrap.Container>
    );
}