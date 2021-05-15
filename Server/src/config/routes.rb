Rails.application.routes.draw do
  root "health_check#index"
  post "/login" => "login#index"
  post "/purchase/add_gold" => "purchase#add_gold"
  post "/purchase/session_fail" => "purchase#session_fail"
end
