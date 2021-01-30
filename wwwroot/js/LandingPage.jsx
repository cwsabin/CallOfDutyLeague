function LandingPage(props) {
    const [currentSeason, setCurrentSeason] = React.useState({ currentSeason: null });

    React.useEffect(() => {
        const getCurrentSeason = async () => {
            const result = await fetch(`https://localhost:44372/getCurrentSeason`);
            const season = await result.json();
            setCurrentSeason(season);
        }

        getCurrentSeason();
    });

    return (
        <div>
            {currentSeason.seasonID}{currentSeason.year}
        </div>
    );
}

ReactDOM.render(
    <LandingPage />,
    document.getElementById('content')
);