Rails.application.routes.draw do
  root "health_check#index"
  post "/login" => "login#index"
end
