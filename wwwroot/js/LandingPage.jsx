import { getCurrentSeason } from "./api.js";
import { TeamStandings } from "./TeamStandings.jsx";

export function LandingPage(props) {
    const [currentSeason, setCurrentSeason] = React.useState({ currentSeason: null });

    React.useEffect(() => {
        const getSeason = async () => {            
            setCurrentSeason(await getCurrentSeason());
        }

        getSeason();
    }, []);

    return (
        <div>
            <TeamStandings season={currentSeason} />
        </div>
    );
}