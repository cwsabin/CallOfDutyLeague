import { getCurrentStandings } from './api.js';

export function TeamStandings(props) {
    const [teamList, setTeamList] = React.useState([]);

    React.useEffect(() => {
        const getStandings = async () => {
            setTeamList(await getCurrentStandings(props.season.year))            
        }

        getStandings()
    }, [props.season]);

    return (
        <div>Standings
            <div>
                <table>
                    <th>Name</th>
                    <th>Wins</th>
                    <th>Losses</th>
                    <th>Map Wins</th>
                    <th>Map Losses</th>
                    {teamList.map((team, index) => (
                        <tr>
                            <td>{team.teamName}</td>
                            <td>{team.wins}</td>
                            <td>{team.losses}</td>
                            <td>{team.mapWins}</td>
                            <td>{team.mapLosses}</td>
                        </tr>
                    ))}
                </table>
            </div>
        </div>
    );
}