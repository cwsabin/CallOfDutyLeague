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
            <div>{teamList.map((team, index) => (
                <p key={index}>{team.MapWins}</p>
            ))}</div>
        </div>
    );
}