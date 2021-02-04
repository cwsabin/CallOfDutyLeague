import { LandingPage } from "./LandingPage.jsx";
import { Team } from "./Team.jsx";
import { NavBar } from "./NavBar.jsx";
import { EventSchedule } from "./EventSchedule.jsx";
import { SeriesDetail } from './SeriesDetail.jsx';

export default function App() {
    return (
        <window.ReactRouterDOM.BrowserRouter>
            <div>                
                <NavBar />
                {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
                <window.ReactRouterDOM.Switch>
                    <window.ReactRouterDOM.Route path="/series/:seriesID" component={SeriesDetail} />
                    <window.ReactRouterDOM.Route path="/teams/:seasonTeamID" component={Team} />
                    <window.ReactRouterDOM.Route path="/events" component={EventSchedule} />
                    <window.ReactRouterDOM.Route path="/" component={LandingPage} />
                </window.ReactRouterDOM.Switch>
            </div>
        </window.ReactRouterDOM.BrowserRouter>
    );
}

ReactDOM.render(
    <App />,
    document.getElementById('content')
);