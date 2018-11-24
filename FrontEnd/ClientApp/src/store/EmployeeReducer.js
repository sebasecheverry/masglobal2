const requestWeatherForecastsType = 'REQUEST_WEATHER_FORECASTS';
const receiveWeatherForecastsType = 'RECEIVE_WEATHER_FORECASTS';
const changeIndex = 'RECEIVE_WEATHER_FORECASTS_INDEX';
const initialState = { forecasts: [], isLoading: false, employeeId: null };

export const actionCreators = {

    changeEmployeeId: employeeId => (dispatch, getState) => {
        dispatch({ type: "RECEIVE_WEATHER_FORECASTS_INDEX", employeeId });        
    },
    requestWeatherForecasts: employeeId => async (dispatch, getState) => {    
    
        let id = getState().employees.employeeId;
        dispatch({ type: requestWeatherForecastsType});

      let url = `https://localhost:44307/api/employees`;

        if (id != null) {          
            url = url + "/" + id;          
      }



      const response = await fetch(url);

       let forecasts = [];      
      try {
          forecasts = await response.json();
      } catch (e) {         
      }

        dispatch({ type: receiveWeatherForecastsType, forecasts });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestWeatherForecastsType) {
    return {
      ...state,      
      isLoading: true
    };
  }

  if (action.type === receiveWeatherForecastsType) {
    return {
      ...state,      
      forecasts: action.forecasts,
      isLoading: false
    };
    }

    if (action.type === changeIndex) {
        return {
            ...state,
            employeeId: action.employeeId,           
        };
    }

  return state;
};
