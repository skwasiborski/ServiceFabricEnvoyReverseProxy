FROM envoyproxy/envoy:v1.7.0
COPY envoy.yaml /etc/envoy/envoy.yaml
COPY startup.sh .
RUN chmod +x startup.sh
CMD ./startup.sh