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

    console.log(team.teamName);

    return (
        <div>
            <h1>{team.teamName}</h1>
            <div>
                <table>
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
                </table>
            </div>
        </div>
    );
}