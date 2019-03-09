import axios from 'axios'

export default class HomeRunLeaders {
    static HRLeaders(onSuccess, onError) {
        axios.get("https://cors-anywhere.herokuapp.com/http://api.sportradar.us/mlb/trial/v6.5/en/seasons/2018/REG/leaders/statistics.json?api_key=4t9zunc2cymse3f2ugzuxj53",
        ).then(onSuccess)
            .catch(onError)
    }
}